/*no usar vectores constantes*/
/*Guardar el iv en el archivo cifrado y primero leerlo */
/*Usar el modo de operacion CTR*/

import javax.crypto.*;
import javax.crypto.spec.*;

/*importar generador de vectores de inicializacion de java para elementos de seguridad */
import java.security.spec.AlgorithmParameterSpec;
public class prueba {
	
	public static int main (String args[]){	
		try {
			SecretKey key = KeyGenerator.getInstance("DES").generateKey();
			AlgorithmParameterSpec paramSpec = new IvParameterSpec(new byte[8]);
			
			Cipher cipher = Cipher.getInstance("AES/CTR/PKCS5Padding");
			Cipher decipher = Cipher.getInstance("AES/CTR/PKCS5Padding");
			
			cipher.init(Cipher.ENCRYPT_MODE, key, paramSpec);
			decipher.init(Cipher.DECRYPT_MODE, key, paramSpec);			
		} catch (Exception e) {
			e.printStackTrace(); 
		}
		return 0;
	}

}
