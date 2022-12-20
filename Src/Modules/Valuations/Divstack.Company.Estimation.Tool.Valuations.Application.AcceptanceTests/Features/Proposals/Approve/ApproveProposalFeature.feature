Feature: Approve Proposal
When inquiry was made 

    @Valuations
    Scenario: Approve Proposal
        Given Request valuation for inquiry '05dbf5ae-e66f-41b2-9938-96b10411e911'
        And Employee suggest valuation for inquiry '05dbf5ae-e66f-41b2-9938-96b10411e911' proposal with price '300' 'USD'
        And Client approve valuation price for inquiry '05dbf5ae-e66f-41b2-9938-96b10411e911'
        Then Valuation price proposal is 'Approved' for inquiry '05dbf5ae-e66f-41b2-9938-96b10411e911'