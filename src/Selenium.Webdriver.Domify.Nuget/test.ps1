$strPath = "C:\Users\yngven\Dropbox\Projects\_GitHub\Selenium.Webdriver.Domify\src\Selenium.Webdriver.Domify.Nuget\lib\net45\Selenium.Webdriver.Domify.dll"
$Assembly = [Reflection.Assembly]::Loadfile($strPath)

$AssemblyName = $Assembly.GetName()
$Assemblyversion =  $AssemblyName.version
$Assembly = null

$path = "C:\Users\yngven\Dropbox\Projects\_GitHub\Selenium.Webdriver.Domify\src\Selenium.Webdriver.Domify.Nuget\Package.nuspec"
$file = New-Object xml
$file.Load($path)

$file.package.metadata.version = $Assemblyversion
$file.Save($path)