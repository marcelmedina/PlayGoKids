@minLength(1)
@maxLength(3)
param environment string

@minLength(3)
@maxLength(60)
param webSiteName string

param appPlanId string

param webAppInsights string

param location string = resourceGroup().location

var aspnetEnvironment = {
  dev: 'Development'
  tst: 'Test'
  uat: 'UAT'
  prd: 'Production'
}

@description('Resource: Apps')
resource appWeb 'Microsoft.Web/sites@2020-12-01' = {
  name: webSiteName
  location: location
  kind: 'app'
  properties:{
    serverFarmId: appPlanId
  }
  tags: {
    displayName: 'Website'
	environment: environment
  }
}

@description('Resource: App Config')
resource appWebConfig 'Microsoft.Web/sites/config@2020-12-01' = {
  name: '${webSiteName}/web'
  dependsOn: [
    appWeb
  ]
  properties: {
    appSettings: [
      {
        name: 'ASPNETCORE_ENVIRONMENT'
        value: aspnetEnvironment[environment]
      }
      {
        name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
        value: webAppInsights
      }
    ]
  }
}
