Feature: AddItem

A short summary of the feature
@ignore
Scenario: I add item to cart
	Given I am Logged in
	And I am on the shop page
	When I add item to cart
	Then item is added to cart