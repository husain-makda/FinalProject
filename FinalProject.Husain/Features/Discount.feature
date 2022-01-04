Feature: Discount

A short summary of the feature

@ignore
Scenario: add a discount
	Given I have added a item to cart
	And I am on the cart page
	When I apply the disocunt code
	Then Disount code is applied to total
