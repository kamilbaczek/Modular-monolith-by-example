Feature: Request Valuation. When inquiry is made then automatically valuation is requested. 
    Valuation request is start of valuation process. When valiation is requested valiation wait for employees price proposal
	
@Valuations
Scenario: Request Valuation
	Given Request valuation for inquiry '05dbf5ae-e66f-41b2-9938-96b10411e911'
    Then Valuation with inquiry '05dbf5ae-e66f-41b2-9938-96b10411e911' is displayed in the valuations list with 'WaitForProposal' state