#
# Copyright (C) crumüs, 2012.
# All rights reserved.
# Ehsan Haghpanah; haghpanah@crumus.com
#

function packages_uninstall([bool]$exit_on_exception)
{
	$list=@{
		"Core\Corn"=@(
			"crumüs.Common.Data.Base",
			"crumüs.Core.Base"
		);
	}

	foreach ($item in $list.GetEnumerator()) {
		foreach ($idol in $item.Value)
		{
			try
			{
				uninstall-package -id $idol -projectname $item.Name
			}
			catch
			{
				Write-Host "packages_uninstall"
				Write-Host $idol -foregroundcolor red -backgroundcolor yellow
				Write-Host $item.Name -foregroundcolor red -backgroundcolor white

				#
				# return back if flag set true
				if ($exit_on_exception)	{
					return $false
				}
			}
		}
	}

	return $true
}

function packages_reinstall([bool]$exit_on_exception)
{
	$list=@{
		"Core\Corn"=@(
			"crumüs.Core.Base",
			"crumüs.Common.Data.Base"
		);
	}

	foreach ($item in $list.GetEnumerator()) {
		foreach ($idol in $item.Value)
		{
			try
			{
				install-package -id $idol -projectname $item.Name
			}
			catch
			{
				Write-Host "packages_reinstall"
				Write-Host $idol -foregroundcolor red -backgroundcolor yellow
				Write-Host $item.Name -foregroundcolor red -backgroundcolor white

				#
				# return back if flag set true
				if ($exit_on_exception)	{
					return $false
				}
			}
		}
	}

	return $true
}

function reinstall_packages
{
	$list=@(
		"Test\Renegade"
	)

	foreach ($item in $list.GetEnumerator())
	{
		try
		{
			install-package -id NLog -Version 4.4.9 -projectname $item
		}
		catch
		{
			Write-Host "reinstall"
			Write-Host $idol -foregroundcolor red -backgroundcolor yellow
			Write-Host $item.Name -foregroundcolor red -backgroundcolor white
		}
	}
}

#packages_uninstall $false
#packages_reinstall $false
#reinstall_packages

#
# main function
if (packages_uninstall -eq $true)
{
	if (packages_reinstall -eq $true)
	{
		Write-Host "packages-update-success" -foregroundcolor blue
	}
	else
	{
		Write-Host "packages-reinstall-failure" -foregroundcolor red
	}
}
else
{
	Write-Host "packages-uninstall-failure" -foregroundcolor red
}