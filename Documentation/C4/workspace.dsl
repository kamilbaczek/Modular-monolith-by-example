workspace {
    model {
        employee = person "Employee"
        client = person "Client"

        customer = person "Customer" "Elastic product customer"

        elastic = softwareSystem "Elastic" {
            clientApp = container "WebUI" "SPA - Angular frontend application that serve UI for Customers" "frontend"
            apiGateway = container "Api Gateway" "" "Azure Api Menager"
            identityMenagmentService = container "Identity Menagment Service" "Enterprise shared customer identity provider" "Rest API"
            accountExp = container "Account Expirence API" "API to authorize and manage customer profile. System is only backend for frontend consuming mostly product services" "Backend For Frontend" "Azure Functions"
            katabat = container "Katabat API" "" "Rest API"
            productServices = container "Product Services" "Monolith application that contains most of elastic features" "Rest API" "WCF"
        }
        stripe = softwareSystem "Stripe" "Payment Processor"
        twillo = softwareSystem "Twillo" "Sms Gateway"
        sendGrid = softwareSystem "SendGrid" "Email Gateway"
        estimationToolSystem = softwareSystem "Estimation Tool" "System to optimize services estimation process" {
        estimationToolContainer = container "Estimation Tool Container" {
            valuations = component "Valuations" "Module"
            users = component "Users" "Module"
            services = component "Services" "Module"
            inquiries = component "Inquiries" "Module"
            priorities = component "Priorities" "Module"
            payments = component "Payments" "Module"
            notifications = component "Notifications" "Module"
        }
        
        usersDatabase = container "Users - Database" "MySql"
        paymentsDatabase = container "Payments - Database" "Mongo"
        notificationsDatabase = container "Notifications - Database" "Mongo"
        servicesDatabase = container "Services - Database" "MySql"
        inquriesDatabase = container "Inquries - Database" "Postgres"
        valuationsDatabase = container "Valuations - Database" "Postgres"
        prioritiesDatabase = container "Priorities - Database" "Mongo"
    }

    employee -> valuations "Estimate services"
    client -> inquiries "Made Inquiry"
    inquiries -> services "Get Services"
    valuations -> inquiries "Get Inquiry Informations"
    inquiries -> valuations "Listen for 'Inquiry Made' event"
    priorities -> valuations "Listen for valuations events requsted/approve/reject"
    notifications -> valuations "Listen for events to notify"
    payments -> valuations "Listen for valuation complete to initialize payment"

    valuations -> valuationsDatabase "Reads from and writes to"
    users -> usersDatabase "Reads from and writes to"
    priorities -> prioritiesDatabase "Reads from and writes to"
    inquiries -> inquriesDatabase "Reads from and writes to"
    notifications -> notificationsDatabase "Reads from and writes to"
    notifications -> twillo "Send Sms"
    notifications -> sendGrid "Send Emails"

    payments -> paymentsDatabase "Reads from and writes to"
    users -> usersDatabase "Reads from and writes to"
    services -> servicesDatabase "Reads from and writes to"
    payments -> stripe "Make payments"


    customer -> clientApp "Use to customer account managment and view account state"
    clientApp -> apiGateway "Consume API's via Gateway"
    apiGateway -> accountExp "Apply security polices and pass Request/Response to Experience Api's"
    accountExp -> identityMenagmentService "Token Validation"
    accountExp -> katabat ""
    accountExp -> productServices "Request via REST endpoints connected with customer account"
}

views {
    component estimationToolContainer {
    include *
    }

    component estimationToolContainer estimationToolContainerValuations {
        include valuations inquiries priorities notifications payments employee client
        }

    component estimationToolContainer estimationToolContainerInquiries {
        include valuations services inquiries client employee
        }

    container elastic {
        include customer clientApp apiGateway accountExp identityMenagmentService katabat productServices
    }

    theme  https://static.structurizr.com/themes/default/theme.json
}