#$Workspace="<em-serializers_DIR_LOCATION>"
#$BuildNumber=20
$Workspace=$ENV:WORKSPACE
$BuildNumber=$ENV:BUILD_NUMBER
Remove-Item $Workspace/nupkg -Force -Recurse

$ErrorActionPreference = "Stop"
mkdir -Path $Workspace/nupkg
mkdir -Path $Workspace/nupkg/EMS.EDXL.CIQ
mkdir -Path $Workspace/nupkg/EMS.EDXL.CT
mkdir -Path $Workspace/nupkg/EMS.EDXL.DE
mkdir -Path $Workspace/nupkg/EMS.EDXL.EXT
mkdir -Path $Workspace/nupkg/EMS.EDXL.GSF
mkdir -Path $Workspace/nupkg/EMS.EDXL.Shared
mkdir -Path $Workspace/nupkg/EMS.EDXL.SitRep
mkdir -Path $Workspace/nupkg/EMS.EDXL.Utilities
mkdir -Path $Workspace/nupkg/EMS.NIEM.EMLC
mkdir -Path $Workspace/nupkg/EMS.NIEM.Incident
mkdir -Path $Workspace/nupkg/EMS.NIEM.Infrastructure
mkdir -Path $Workspace/nupkg/EMS.NIEM.MutualAid
mkdir -Path $Workspace/nupkg/EMS.NIEM.NIEMCommon
mkdir -Path $Workspace/nupkg/EMS.NIEM.Resource
mkdir -Path $Workspace/nupkg/EMS.NIEM.Sensor

$dir = dir $Workspace/nupkg | ?{$_.PSISContainer}
foreach ($d in $dir){
    $name = Join-Path -Path $d.FullName -ChildPath '\lib'
    mkdir -Path $name
    $name = Join-Path -Path $d.FullName -ChildPath '\lib\netstandard1.6.1'
    mkdir -Path $name
    $name = Join-Path -Path $d.FullName -ChildPath '\lib\net45'
    mkdir $name
	$name = Join-Path -Path $d.FullName -ChildPath '\lib\portable-net45+wp80+win8+wpa81'
    mkdir $name
}

$dir = dir $Workspace/EDXL | ?{$_.PSISContainer}
foreach ($d in $dir){
    $name = Join-Path -Path $d.FullName -ChildPath ('\bin\Release\netstandard1.6.1\' + $d.Name + '.dll')
    Copy-Item -Path $name -Destination ($Workspace + '\nupkg\' + $d.Name + '\lib\netstandard1.6.1\')
    $name = Join-Path -Path $d.FullName -ChildPath ('\bin\Release\netstandard1.6.1\' + $d.Name + '.xml')
    Copy-Item -Path $name -Destination ($Workspace + '\nupkg\' + $d.Name + '\lib\netstandard1.6.1\')
}

$dir = dir $Workspace/NIEM | ?{$_.PSISContainer}
foreach ($d in $dir){
    $name = Join-Path -Path $d.FullName -ChildPath ('\bin\Release\netstandard1.6.1\' + $d.Name + '.dll')
    Copy-Item -Path $name -Destination ($Workspace + '\nupkg\' + $d.Name + '\lib\netstandard1.6.1\')
    $name = Join-Path -Path $d.FullName -ChildPath ('\bin\Release\netstandard1.6.1\' + $d.Name + '.xml')
    Copy-Item -Path $name -Destination ($Workspace + '\nupkg\' + $d.Name + '\lib\netstandard1.6.1\')
}

$dir = dir $Workspace/EDXLcsproj | ?{$_.PSISContainer}
foreach ($d in $dir){
    if($d.Name.StartsWith("EMS.EDXL"))
    {
        $name = Join-Path -Path $d.FullName -ChildPath ('\bin\Release\' + $d.Name + '.dll')
        Copy-Item -Path $name -Destination ($Workspace + '\nupkg\' + $d.Name + '\lib\portable-net45+wp80+win8+wpa81\')
        $name = Join-Path -Path $d.FullName -ChildPath ('\bin\Release\' + $d.Name + '.xml')
        Copy-Item -Path $name -Destination ($Workspace + '\nupkg\' + $d.Name + '\lib\portable-net45+wp80+win8+wpa81\')  
    }
    else
    {
        $name = Join-Path -Path $d.FullName -ChildPath ('\lib\net45\EMS.EDXL.' + $d.Name + '.dll')
        Copy-Item -Path $name -Destination ($Workspace + '\nupkg\EMS.EDXL.' + $d.Name + '\lib\net45\')
        $name = Join-Path -Path $d.FullName -ChildPath ('\lib\net45\EMS.EDXL.' + $d.Name + '.xml')
        Copy-Item -Path $name -Destination ($Workspace + '\nupkg\EMS.EDXL.' + $d.Name + '\lib\net45\')
        $name = Join-Path -Path $d.FullName -ChildPath ('EMS.EDXL.' + $d.Name + '.nuspec')
        Copy-Item -Path $name -Destination ($Workspace + '\nupkg\EMS.EDXL.' + $d.Name )    
    }
    
}

$dir = dir $Workspace/NIEMcsproj | ?{$_.PSISContainer}
foreach ($d in $dir){
    if($d.Name.StartsWith("EMS.NIEM"))
    {
        $name = Join-Path -Path $d.FullName -ChildPath ('\bin\Release\' + $d.Name + '.dll')
        Copy-Item -Path $name -Destination ($Workspace + '\nupkg\' + $d.Name + '\lib\portable-net45+wp80+win8+wpa81\')
        $name = Join-Path -Path $d.FullName -ChildPath ('\bin\Release\' + $d.Name + '.xml')
        Copy-Item -Path $name -Destination ($Workspace + '\nupkg\' + $d.Name + '\lib\portable-net45+wp80+win8+wpa81\')  
    }
    else 
    {
        $name = Join-Path -Path $d.FullName -ChildPath ('\lib\net45\EMS.NIEM.' + $d.Name + '.dll')
        Copy-Item -Path $name -Destination ($Workspace + '\nupkg\EMS.NIEM.' + $d.Name + '\lib\net45\')
        $name = Join-Path -Path $d.FullName -ChildPath ('\lib\net45\EMS.NIEM.' + $d.Name + '.xml')
        Copy-Item -Path $name -Destination ($Workspace + '\nupkg\EMS.NIEM.' + $d.Name + '\lib\net45\')
        $name = Join-Path -Path $d.FullName -ChildPath ('EMS.NIEM.' + $d.Name + '.nuspec')
        Copy-Item -Path $name -Destination ($Workspace + '\nupkg\EMS.NIEM.' + $d.Name)
    }
}

$dir = dir $Workspace/nupkg | ?{$_.PSISContainer}
foreach ($d in $dir){
    $name = Join-Path -Path $d.FullName -ChildPath ($d.Name + '.nuspec')
    $content = [IO.File]::ReadAllText($name)
    $content = $content.Replace('$version$', '1.0.'+$BuildNumber)
    [IO.File]::WriteAllText($name,$content)
    & nuget pack $name -outputdirectory $Workspace/nupkg
}