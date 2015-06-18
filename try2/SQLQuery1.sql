select * from AspNetRoles;

select * from AspNetUserRoles;

select * from AspNetUsers;

insert into AspNetRoles(Id,Name) values(1,'admin');

insert into AspNetRoles(Id,Name) values(2,'employee');

admin - b5656076-0915-4dc2-bf66-a31ce4d2c7d1

employee - cff7fc6d-8d7f-434d-ade8-81c771d138dc

employee2 - 7a5ab3f1-09b8-47da-b3a5-a98affbf0fbf

insert into AspNetUserRoles(UserId,RoleID) values ('b5656076-0915-4dc2-bf66-a31ce4d2c7d1',1);

insert into AspNetUserRoles(UserId,RoleID) values ('cff7fc6d-8d7f-434d-ade8-81c771d138dc',2);

insert into AspNetUserRoles(UserId,RoleID) values ('7a5ab3f1-09b8-47da-b3a5-a98affbf0fbf',2);
