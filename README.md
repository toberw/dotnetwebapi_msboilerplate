# Task Management Application
Basic RESTful API supporting CRUD functionality that allows users to manage lists with different tasks attached to them. This is going to be made entirely using ASP.net 


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

