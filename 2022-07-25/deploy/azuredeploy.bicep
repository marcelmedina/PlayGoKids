param resourceGroupName string

@minLength(1)
@maxLength(3)
param environment string

@minLength(3)
param appPlanName string

@description('Describes plan\'s pricing tier and capacity. Check details at https://azure.microsoft.com/en-us/pricing/details/app-service/')
@allowed([
  'F1'
  'D1'
  'B1'
  'B2'
  'B3'
  'S1'
  'S2'
  'S3'
  'P1'
  'P2'
  'P3'
  'P4'
])
param appPlanSku string = 'F1'

param location string = resourceGroup().location

var webSiteName = 'sample-web-${environment}'

@description('Module: App Plan')
module appPlan './modules/appPlan.bicep' = {
  name: 'appPlanModule'
  params: {
    appPlanName: appPlanName
    appPlanSku: appPlanSku
    location: location
    environment: environment
  }
  scope: resourceGroup(resourceGroupName)
}

@description('Module: Application Insights')
module ai './modules/insights.bicep' = {
  name: 'appInsightsModule'
  params: {
    webSiteName: webSiteName
    location: location
    environment: environment
  }
}

@description('Module: Apps')
module app './modules/apps.bicep' = {
  name: 'appModule'
  params: {
    appPlanId: appPlan.outputs.appPlanId
    webSiteName: webSiteName
    webAppInsights: ai.outputs.aiWebInstrumentationKey
    location: location
    environment: environment
  }
}
