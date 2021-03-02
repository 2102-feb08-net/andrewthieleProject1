const mysql = require('mysql');

const pool = mysql.createPool({
  connectionLimit: 10,
  host: 'localhost',
  user: 'root',
  password: 'qEAfs7WD40',
  database: 'workouts_db'
});

module.exports.pool = pool;