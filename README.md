# Task Management Application
RESTful API made with C# using ASP.NET Core that connects to an existing database. I planned out the existing database and following documentation to reverse engineer it [Here](https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli)

## Database Plan & Setup
[DBDiagram](https://dbdiagram.io) was used to plot out my database structure. Below is the various tables to be used in this project, and their relationships with eachother.
After creating database use the file [msbp_mysql.sql](./msbp_mysql.sql) to create tables shown below. 

```
Table users as U {
  id int [pk, increment] // auto-increment
  username varchar
  password varchar
  full_name varchar
  created_at timestamp
  country_code int
}

Table task_list {
  id int [pk, increment]
  user_id int [ref: > users.id]
  created_at timestamp
  value varchar
  description varchar
}

Table task_items {
  id int [pk, increment]
  list_id int [ref: > task_list.id]
  task varchar
}

Table task_comment {
  id int [pk, increment]
  user_id int [ref: > users.id]
  item_id int [ref: > task_items.id]
  value varchar
}
```

