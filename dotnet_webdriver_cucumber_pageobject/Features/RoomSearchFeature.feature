Feature: RoomSearchFeature
	In order to make sure search functionality is working as expected 
	As a analyst
	I want to add automation tests for search feature


Background: 
	Given I am on home page


Scenario: Verify search results displayed 
	When I select checkin date as 'today'
	And I select checkout date as 'today~3'
	And I entered location as 'london'
	And I click on search button 
	Then I should see results listed in results page

Scenario Outline: Verify error messages for invalid search
	When I entered location as '<location>' in search box
	And I click on search button 
	Then I should see search error message as 'To search, please select a location or tag from the menu which appears when typing.'
	Examples: 
	| location |
	| ttttt    |
	| 2245     |
	| %$£&     |

