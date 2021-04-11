public class SimpleRuntimeException extends RuntimeException {
	
	private String tmp = "My exception";
	
	public SimpleRuntimeException() {};
	public SimpleRuntimeException(String tmp) { this.tmp = tmp; };
	
	public String toString() { return tmp; }
}