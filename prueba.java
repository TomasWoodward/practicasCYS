/*no usar vectores constantes*/
/*Guardar el iv en el archivo cifrado y primero leerlo */
/*Usar el modo de operacion CTR*/

import javax.crypto.*;
import javax.crypto.spec.*;
import java.security.spec.AlgorithmParameterSpec;

public class prueba {
	/*crear vector de inicializacion aleatorio con java.security*/

	/*guardar el iv en el archivo cifrado */

	public static int main (String args[]){	
		try {
			kkkkkkkk

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
