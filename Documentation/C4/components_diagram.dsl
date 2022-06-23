workspace {

model {
    employee = person "Employee"
    stripe = softwareSystem "Payment Processor"

    s = softwareSystem "Software System" {
    estimationToolContainer = container "Estimation Tool Container" {
                            bootstrapper = component "Bootstraper" "Module"
                            valuations = component "Valuations"
                            users = component "Users"
                                    services = component "Services"
                                    inquiries = component "Inquiries"
                                    priorities = component "Priorities"
    payments = component "Payments"
    notifications = component "Notifications"

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
payments -> paymentsDatabase "Reads from and writes to"
users -> usersDatabase "Reads from and writes to"

payments -> stripe "Make payments"
}

views {
component estimationToolContainer {
include *
autoLayout tb
}

theme  https://static.structurizr.com/themes/default/theme.json
}
}