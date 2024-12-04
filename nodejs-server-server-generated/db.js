const mysql = require('mysql');
// Crear la conexión
const connection = mysql.createConnection({
  host: 'localhost',    
  user: 'root',    
  password: '', 
  database: 'cys'       
});

// Establecer la conexión
connection.connect((err) => {
  if (err) {
    console.error('Error conectando a la base de datos:', err.stack);
    return;
  }
  console.log('Conexión exitosa con ID:', connection.threadId);
});

module.exports = connection;