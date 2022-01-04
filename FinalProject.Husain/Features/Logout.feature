Feature: Order and logout

A short summary of the feature

@ignore
Scenario: View order details and logout
	Given I am logged in
	And On my account page
	When I go on orders
	Then I can view order number
	Then I can Logout 
