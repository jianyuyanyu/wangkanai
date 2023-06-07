# <img src="https://raw.githubusercontent.com/wangkanai/IdentityAdmin/main/asset/Identity-admin-logo.svg?sanitize=true" width="650" alt="IdentityAdmin" />

***(Alpha Development)***

IdentityAdmin is a free, open source that provides the necessary administration portal for managing [IdentityServer](https://github.com/IdentityServer/) to manage clients and users. IdentityAdmin will allow easier implementation of IdentityServer whom provides no administration tool for managing its configuration.

**Please show some me love and click on** :star: This help motivate me to continue on developing the project.

[![NuGet Badge](https://buildstats.info/nuget/wangkanai.IdentityAdmin)](https://www.nuget.org/packages/wangkanai.IdentityAdmin)
[![NuGet Badge](https://buildstats.info/nuget/wangkanai.IdentityAdmin?includePreReleases=true)](https://www.nuget.org/packages/wangkanai.IdentityAdmin)

[![Build Status](https://dev.azure.com/wangkanai/GitHub/_apis/build/status/wangkanai?branchName=main)](https://dev.azure.com/wangkanai/GitHub/_build/latest?definitionId=20&branchName=main)
[![Open Collective](https://img.shields.io/badge/open%20collective-support%20me-3385FF.svg)](https://opencollective.com/wangkanai)
[![Patreon](https://img.shields.io/badge/patreon-support%20me-d9643a.svg)](https://www.patreon.com/wangkanai)
[![GitHub](https://img.shields.io/github/license/wangkanai/wangkanai)](https://github.com/wangkanai/wangkanai/blob/main/LICENSE)

## Overview

Installation of IdentityAdmin

```powershell
PM> install-package Wangkanai.IdentityAdmin
```

Implement of the library into your web application is done by configuring the `Startup.cs` by adding the IdentityAdmin service in the `ConfigureServices` method.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();

    services.AddIdentityServer()
        .AddAspNetIdentity<ApplicationUser>();

    services.AddIdentityAdmin<ApplicationUser>();
}
```

Adding the IdentityAdmin middleware to the pipeline. The IdentityAdmin middleware is enabled in the `Configure` method of *Startup.cs* file.

```csharp
public void Configure(IApplicationBuilder app)
{
    app.UseIdentityServer();

    app.UseIdentityAdmin();

    app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
}
```

### Directory Structure

* `src` - The source code of this project lives here.
* `test` - The unit tests code of this project to valid that everything pass specs.
* `sample` - The sample code of this project lives here. 

### Contributing

All contribution are welcome, please contact the author.