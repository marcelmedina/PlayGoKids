@minLength(1)
@maxLength(3)
param environment string

@minLength(3)
@maxLength(40)
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
param appPlanSku string = 'B1'

param location string = resourceGroup().location

@description('Resource: App Plan')
resource appPlan 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: appPlanName
  location: location
  sku: {
    name: appPlanSku
  }
  kind: 'app'
  tags: {
    displayName: 'HostingPlan'
	environment: environment
  }
}

output appPlanId string = appPlan.id
