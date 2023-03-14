# CalendarToInvoice - A hack for HackTogether Microsoft Graph & .NET

[![Hack Together: Microsoft Graph and .NET](https://img.shields.io/badge/Microsoft%20-Hack--Together-orange?style=for-the-badge&logo=microsoft)](https://github.com/microsoft/hack-together)

## Description
This Blazor Server Hack generates Invoices from Outlook Calendar Events utilizing Microsoft Graph. 

## The Situation
You are a lawyer in the Star Wars Universe. You are busy dealing with Mando's and Luke's speeding tickets, Luke's case with the Death Star...and Moff Gideons case regarding the nuking of Mandalore.

## Setup

Register the app in your AzureAD

### Required API-Permissions

Microsoft Graph
- Calendars.ReadWrite
- Contacts.ReadWrite
- Files.ReadWrite
- User.Read

### Enter your credentials in .appsettings

- TenantId
- ClientId
- ClientSecret

### Follow the Wizard 🧙‍  

On first startup the app checks if there is a 'CalendarToInvoice' folder in your OneDrive's root. If it is not, the wizard opens and you can follow its steps. 

#### Wizard Step One - Folder and Files
```
root
│
└───CalendarToInvoice
    │
    └───Data
    │      Settings.xlsx
    │   
    └───Invoices           
```

#### Wizard Step Two - Outlook Data

- 2 Master Categories are added (Billable, Posted)
- 4 Contacts
- Events in your Calendar from the first of last month to today. (50% non-billable Research events and 50% Random Customer Events)

## HowTo

### Create Invoices

1. Go to 'Create Invoices'
2. Select a Customer/Month combination
3. Press 'Save to PDF'

### Look at Posted Invoices

1. Go to 'Posted Invoices'
2. Press the icon in the View column

### Reset your Folders, Files, Customers and Events

1. Go to 'Settings'
2. Press the button

### Create a new billable Event

1. Create an event in outlook as you usually do
2. Invite a contact as participant that has the customer category attached to it
3. Add the billable Category to the event
4. Done

### Repair the Han Solo Events

You might have noticed some billable events that can't be posted because you can't select Han Solo as a customer. This is because the Han Solo contact doesn't have the customer category attached to it. Just add it in Outlook.

## Notes

- Billable events are shown in yellow in your Outlook Calendar
- Posted events are shown in green in your Outlook Calendar
- Repeat after me: Excel is not a Database. I just wanted to see how far I can take it.

## ToDo's

- Remove Settings.xlsx and move the data to a better place
- Truly remove MasterCategories
- Use $count Requests