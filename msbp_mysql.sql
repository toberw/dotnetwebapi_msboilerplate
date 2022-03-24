CREATE TABLE `users` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `username` varchar(255),
  `password` varchar(255),
  `full_name` varchar(255),
  `created_at` timestamp,
  `country_code` int
);

CREATE TABLE `task_list` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `user_id` int,
  `created_at` timestamp,
  `value` varchar(255),
  `description` varchar(255)
);

CREATE TABLE `task_items` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `list_id` int,
  `task` varchar(255)
);

CREATE TABLE `task_comment` (
  `id` int PRIMARY KEY AUTO_INCREMENT,
  `user_id` int,
  `item_id` int,
  `value` varchar(255)
);

ALTER TABLE `task_list` ADD FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

ALTER TABLE `task_items` ADD FOREIGN KEY (`list_id`) REFERENCES `task_list` (`id`);

ALTER TABLE `task_comment` ADD FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

ALTER TABLE `task_comment` ADD FOREIGN KEY (`item_id`) REFERENCES `task_items` (`id`);
