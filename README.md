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
Create your Document intelligence in Azure.

Then add your variables:
- Endpoint
- ApiKey
- documentURI