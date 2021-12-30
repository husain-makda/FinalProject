Feature: Checkout

A short summary of the feature

@tag1
Scenario: I can checkout
	Given I have added item to cart
	And I am on the checkout page
	When I enter all billing details
	Then I can place the order
