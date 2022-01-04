Feature: Login

A short summary of the feature

@ignore
Scenario: Login to the demo website
	Given I am on the account page
	When I enter a valid username and password
	Then I am logged in