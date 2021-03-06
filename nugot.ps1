#
# Copyright (C) scenüs, 2012.
# All rights reserved.
# Ehsan Haghpanah; haghpanah@scenus.com
#

# creating and initializaing nuget feed
# nuget init C:\NuGet\scenus\G1\packages \\scenus-local-nuget-server\packages

#
# packaging project(s) output(s)
nuget pack .\Core\Corn\Corn.csproj -Verbosity detailed -Properties Configuration=Release -Prop Platform=x64

#
# pushing packages to remote nuget repository
nuget push -Source C:\NuGet\scenus\G1\packages scenüs.*.nupkg 

#
# clearing the local path
Remove-Item scenüs.*.nupkg