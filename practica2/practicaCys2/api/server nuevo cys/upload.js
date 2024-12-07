const multer = require('multer');
const path = require('path');

// Configuración de Multer
const uploadDir = path.join(__dirname, 'uploads'); // Cambia 'uploads' si quieres otra carpeta
const storage = multer.diskStorage({
    destination: (req, file, cb) => {
        cb(null, uploadDir); // Carpeta destino
    },
    filename: (req, file, cb) => {
        const uniqueName = `${Date.now()}-${file.originalname}`; // Nombre único
        cb(null, uniqueName); // Nombre único para evitar colisiones
    },
});

const upload = multer({ storage });

module.exports = upload;