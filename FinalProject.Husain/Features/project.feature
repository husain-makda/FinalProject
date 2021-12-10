Feature: project

I want to be able to log in and purchase a product on the website.

@tag1
Scenario: Login to the demo website
	Given I am on the login page
	When I use a valid username and password
	When I add a cap to cart which I view
	Then I am able to checkout
	Then I can place order
	
	
	
	
	
	
	


