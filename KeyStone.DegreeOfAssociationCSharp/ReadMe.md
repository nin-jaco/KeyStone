Reason for this query (I overdid it a bit with the tables - only need the one in any way). Linq and ORM are only a few lines of code. Grouped List

This had me snookered for a bit, many of the parent shows has been seen but i was expecting to see more than one child.

I tested it as follows:
select * from Parties where partyName = 12593668

select * from GrandParents where GrandParentGuid = '6cdb718e-cdfd-462f-b406-76da96b75219'

select IdParty from Associations where --idParty = 19 and 
IdGrandParent = 1333 group by IdParty having count(idParty) > 1

select IdGrandParent from Associations where idParty = 19 --and IdGrandParent = 1333 
group by IdGrandParent having count(IdGrandParent) > 1

select IdGrandParent, IdParty from Associations --where idParty = 19 --and IdGrandParent = 1333 
group by IdGrandParent, IdParty having count(IdParty) > 1

//-->[Interpretation 2] 
Then i realised your question could be interpreted differently.  Whereas you only want the top 5 for any in the top 10


*****************************
Instructions:
Script folder contains the script and data in one insert.

