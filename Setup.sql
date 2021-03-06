USE contractos;

-- CREATE TABLE jobs(
--   id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   location VARCHAR(255) NOT NULL,
--   PRIMARY KEY(id)
-- );
-- CREATE TABLE contractors(
--   id int NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   location VARCHAR(255) NOT NULL,
--   PRIMARY KEY(id)
-- );

CREATE TABLE bids (
  id int NOT NULL AUTO_INCREMENT,
  jobId int NOT NULL ,
  contractorId int NOT NULL,
  price int NOT NULL,
  PRIMARY KEY(id),
  FOREIGN KEY (jobId)
        REFERENCES jobs (id)
        ON DELETE CASCADE,
  FOREIGN KEY (contractorId)
        REFERENCES contractors (id)
        ON DELETE CASCADE
);
