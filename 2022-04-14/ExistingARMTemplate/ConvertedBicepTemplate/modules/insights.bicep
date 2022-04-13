@minLength(1)
@maxLength(3)
param environment string

@minLength(3)
@maxLength(60)
param webSiteName string

param location string = resourceGroup().location

@description('Resource: Application Insights')
resource aiWeb 'Microsoft.Insights/components@2020-02-02' = {
  name: webSiteName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
  }
  tags: {
    displayName: 'AppInsightsComponent'
	environment: environment
  }
}

output aiWebInstrumentationKey string = aiWeb.properties.InstrumentationKey
