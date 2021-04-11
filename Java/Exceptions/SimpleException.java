public class SimpleException extends Exception {
	
	private String tmp = "Simple exception";
	
	public SimpleException() {};
	public SimpleException(String tmp) { this.tmp = tmp; };
	
	public String toString() { return tmp; }
}