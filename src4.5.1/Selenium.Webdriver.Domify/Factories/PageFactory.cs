using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Moq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Selenium.Webdriver.Domify.Factories
{
    public class PageProxyFactory
    {
        private static LambdaExpression GetPropertyExpression<T>(string propertyName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "i");
            MemberExpression property = Expression.Property(parameter, propertyName);
            var propertyType = typeof(T).GetProperty(propertyName).PropertyType;
            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), propertyType);

            var yourExpression = Expression.Lambda(delegateType, property, parameter);
            return yourExpression;
        }


        static object GetFinderMethod(Type type, Page page, By finder)
        {
            Type funcType = typeof(Func<>).MakeGenericType(type);

            var wrapper = Activator.CreateInstance(typeof(ElementFinderWrapper), new object[] { page, finder }, null);

            MethodInfo method = wrapper.GetType().GetMethod("Get").MakeGenericMethod(type);
            return Delegate.CreateDelegate(funcType, wrapper, method);
        }

        private static By CreateFinder(FindsByAttribute findsBy)
        {
            var u = findsBy.Using;
            switch (findsBy.How)
            {
                case How.Id:
                    return By.Id(u);
                case How.Name:
                    return By.Name(u);
                case How.TagName:
                    return By.TagName(u);
                case How.ClassName:
                    return By.ClassName(u);
                case How.CssSelector:
                    return By.CssSelector(u);
                case How.LinkText:
                    return By.LinkText(u);
                case How.PartialLinkText:
                    return By.PartialLinkText(u);
                case How.XPath:
                    return By.XPath(u);
                case How.Custom:
                    throw new NotImplementedException("Custom is not supported");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private static void MockProperty<T>(Mock<T> pageMock, PropertyInfo property) where T : Page, new()
        {
            By finder = CreateFinder(property.GetCustomAttribute<FindsByAttribute>());

            var finderFunc = GetFinderMethod(property.PropertyType, pageMock.Object, finder);

            LambdaExpression propertyExpression = GetPropertyExpression<T>(property.Name);
            var propertyType = typeof(T).GetProperty(property.Name).PropertyType;

            var setupMethod = pageMock.GetType().GetMethods().Single(d => d.Name.Equals("Setup") && d.IsGenericMethod);
            MethodInfo generic = setupMethod.MakeGenericMethod(propertyType);
            var setup = generic.Invoke(pageMock, new[] { propertyExpression });
            var methods = setup.GetType().GetMethods().Where(m => m.Name.Equals("Returns") && !m.IsGenericMethod);

            methods.First().Invoke(setup, new[] { finderFunc });
        }


        internal static T CreatePageProxy<T>(IDocument document)
            where T : Page, new()
        {
            var pageMock = new Mock<T>();
            pageMock.Setup(p => p.Document).Returns(document);

            foreach (var property in typeof(T).GetProperties().Where(c => c.GetAccessors().Any(a => a.IsVirtual) && c.GetCustomAttribute<FindsByAttribute>() != null))
            {
                MockProperty(pageMock, property);
            }
            return pageMock.Object;
        }
    }
}