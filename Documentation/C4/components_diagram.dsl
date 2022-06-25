workspace {
    model {
        employee = person "Employee"
        client = person "Client"
        stripe = softwareSystem "Stripe" "Payment Processor"
        twillo = softwareSystem "Twillo" "Sms Gateway"
        sendGrid = softwareSystem "SendGrid" "Email Gateway"

        estimationToolSystem = softwareSystem "Estimation Tool" "System to optimize services estimation process" {
        estimationToolContainer = container "Estimation Tool Container" {
            bootstrapper = component "Bootstraper" "Module"
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

    employee -> bootstrapper "Estimate services"
    client -> bootstrapper "Accept/Reject/View valuations"

    bootstrapper -> valuations "Compose"
    bootstrapper -> priorities "Compose"
    bootstrapper -> inquiries "Compose"
    bootstrapper -> payments "Compose"
    bootstrapper -> services "Compose"
    bootstrapper -> users "Compose"
    bootstrapper -> notifications "Compose"

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

}

views {
    component estimationToolContainer {
    include *
    autoLayout tb
    }

    component estimationToolContainer estimationToolContainerValuations {
        include bootstrapper inquiries notifications employee client
        autoLayout tb
        }

    theme  https://static.structurizr.com/themes/default/theme.json
    }
}