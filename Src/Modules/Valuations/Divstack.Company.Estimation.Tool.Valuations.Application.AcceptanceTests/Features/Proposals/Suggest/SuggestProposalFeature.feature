Feature: Suggest Proposal
	When inquiry was made 

@Valuations
Scenario: Suggest Proposals
	Given Request valuation for inquiry '05dbf5ae-e66f-41b2-9938-96b10411e911'
	And Employee suggest valuation for inquiry '05dbf5ae-e66f-41b2-9938-96b10411e911' proposal with price '300' 'USD'
	Then Proposal is suggested for valuation with inquiryId '05dbf5ae-e66f-41b2-9938-96b10411e911' with price '300' 'USD'
	And Valuation with inquiry '05dbf5ae-e66f-41b2-9938-96b10411e911' is displayed in the valuations list with 'WaitForClientDecision' state