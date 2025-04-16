resource "azurerm_cognitive_account" "docintelligence_account" {
  name                = var.account_name
  location            = azurerm_resource_group.docintelligence_rg.location
  resource_group_name = azurerm_resource_group.docintelligence_rg.name
  kind                = "DocumentIntelligence"
  sku_name            = "F0"

  properties {
    network_acls {
      default_action = "Allow"
    }
  }
}