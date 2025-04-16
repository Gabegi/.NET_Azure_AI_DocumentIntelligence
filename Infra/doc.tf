resource "azurerm_cognitive_account" "doc-ai" {
  name                = "testdfdfadsfaeafd"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  kind                = "DocumentIntelligence"
  sku_name            = "F0"
}