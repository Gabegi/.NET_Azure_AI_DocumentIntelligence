# .NET_Azure_AI_DocumentIntelligence

Sample project to illustrate the use of Azure.AI.DocumentIntelligence

## App 
The user will input a keyword and the app must check if the document contains the keyword.
The return statement should provide further details.

## Flow

- User send a word per POST API
- App forwards word to AI Azure Client
- Client analyses document and sees if word in document

## Testing
- Rung the app
- Open postman and send a post request to  https://localhost:7091/getword
- Body
```
{
    "KeyWord": "account"
}
```

## Getting started
Add your variables:
- Endpoint
- ApiKey
- documentURI

You need to add a folder called vars and add a tfvars file in there.

Potential improvement is to use modules

Navigate to the repo and run:

terraform init
terraform plan -var-file="vars/values.tfvars"
terraform apply -auto-approve -var-file="vars/values.tfvars"
terraform destroy -var-file="vars/values.tfvars"