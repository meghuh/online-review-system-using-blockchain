# TEST PLAN

## Table no: Low level test plan

| **Test ID** | **Description**                                              | **Exp I/P** | **Exp O/P** | **Actual Out** |**Status**  |
|-------------|--------------------------------------------------------------|------------|-------------|----------------|------------------|
|  1       | Click on Shop Registration |  Input Required Details | Based on Input Details Should successfully Register to Application|Shop Successfully register to application with details |Pass |
|  2      |Click on Post Comment to Product | Post Comment Details  |Post Comment details (Product Based) should store to database with SHA,Rijndael, Blockchain Successfully| Post Comment  details (Product Based) stored to database with SHA, Rijndael, Blockchain Successfully | Pass| 
|  3       |Click on View Product Review  |Product Review|Product Review Viewed Successfully,If Review Tamper then Recover Review Successfully|View Product Review Successfully,If Review Tamper then Recover Review Successfully   | Pass|

## Table no: High level test plan

| **Test ID** | **Description**                                              | **Exp IN** | **Exp OUT** | **Actual Out** |**Test Type**  |
|-------------|--------------------------------------------------------------|------------|-------------|----------------|------------------|
|   1     |Secured Online review system requires the necessity for the encryptioin algorithms to protect the feedbacks from customers from tampering |  Having the original review unaltered  | the original reviews can be gained back from the database |the actual reviews are present and retrieved from the database where all the reviews are stored |Requirement based |
|    2       |Online marketing business using the secured review system to improve their business |  to obtain reviews without any falsification| original reviews obtained inspite of modification by the third party using blockchain | Reviews are obtained|Scenario based    |
