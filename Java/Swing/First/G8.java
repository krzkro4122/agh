package First;

import java.awt.FlowLayout;
import java.awt.Frame;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import java.awt.event.WindowStateListener;

import javax.swing.JButton;
import javax.swing.JFrame;

public class G8 {

	static JFrame jframe = null;
	
    public static void createAndShowGUI() {
    	
    	ActionListener myActionListener = new ActionListener() {
    		public void actionPerformed(ActionEvent e) {
    			System.out.println("[ActionListener] Button = "+e.getActionCommand());
    		}    		
    	};
    	
    	MouseMotionListener myMouseMotionListener = new MouseMotionListener() {
			public void mouseDragged(MouseEvent e) {
    			System.out.println("[MouseMotionListener] Dragged! Button = "+((JButton) e.getSource()).getText());
			}

			public void mouseMoved(MouseEvent e) {
    			System.out.println("[MouseMotionListener] Moved! Button = "+((JButton) e.getSource()).getText());
			}
    	};
    	   	
    	MouseListener myMouseListener = new MouseListener() {
			public void mouseClicked(MouseEvent e) {
    			System.out.println("[MouseListener] Clicked! Button = "+((JButton) e.getSource()).getText());
			}

			public void mouseEntered(MouseEvent e) {
    			System.out.println("[MouseListener] Entered! Button = "+((JButton) e.getSource()).getText());
			}

			public void mouseExited(MouseEvent e) {
    			System.out.println("[MouseListener] Exited! Button = "+((JButton) e.getSource()).getText());
			}

			public void mousePressed(MouseEvent e) {
    			System.out.println("[MouseListener] Pressed! Button = "+((JButton) e.getSource()).getText());
			}

			public void mouseReleased(MouseEvent e) {
    			System.out.println("[MouseListener] Released! Button = "+((JButton) e.getSource()).getText());
			}
    		
    	};
    	
    	WindowListener myWindowListener = new WindowListener() {
			public void windowActivated(WindowEvent e) {
    			System.out.println("[WindowListener] Activated!"+" visible="+jframe.isVisible()+", active="+jframe.isActive());
			}

			public void windowClosed(WindowEvent e) {
    			System.out.println("[WindowListener] Closed!");
			}

			public void windowClosing(WindowEvent e) {
    			System.out.println("[WindowListener] Closing!");
			}

			public void windowDeactivated(WindowEvent e) {
    			System.out.println("[WindowListener] Deactivated!");
    		}

			public void windowDeiconified(WindowEvent e) {
    			System.out.println("[WindowListener] Deiconified!");
			}

			public void windowIconified(WindowEvent e) {
    			System.out.println("[WindowListener] Iconified!");
    			jframe.setTitle("kuku");
    			jframe.setVisible(true);
    		}

			public void windowOpened(WindowEvent e) {
    			System.out.println("[WindowListener] Opened!"+" visible="+jframe.isVisible()+", active="+jframe.isActive());
			}    		
    	};

    	WindowStateListener myWindowStateListener = new WindowStateListener() {
			public void windowStateChanged(WindowEvent e) {
    			System.out.print("[WindowStateListener] State Changed: ");
    			switch(e.getNewState()) {
    			    case Frame.NORMAL:
    			    	System.out.println("Normal! ");
    			    	break;
    			    case Frame.ICONIFIED:
    			    	System.out.println("Iconfied! ");
    			    	break;
    			    case Frame.MAXIMIZED_HORIZ:
    			    case Frame.MAXIMIZED_VERT:
    			    case Frame.MAXIMIZED_BOTH:
    			    	System.out.println("Maximized! ");
    			    	break;
    			    default:
    			    	System.out.println(e.getNewState());
    			    	break;
    			}
			}
    	};
    	
    	JFrame jf = new JFrame("My First Frame");
    	jframe=jf;
        jf.setLayout(new FlowLayout());
        jf.addWindowListener(myWindowListener);
        jf.addWindowStateListener(myWindowStateListener);
        
        JButton jb = new JButton("Hello!");
        jb.addActionListener(myActionListener);
        jb.addMouseMotionListener(myMouseMotionListener);
        jb.addMouseListener(myMouseListener);
        jf.getContentPane().add(jb);

        JButton jb2 = new JButton("How are you?");
        jb2.addActionListener(myActionListener);
        jb2.addMouseMotionListener(myMouseMotionListener);
        jb2.addMouseListener(myMouseListener);
        jf.getContentPane().add(jb2);
        
        jf.pack();
        jf.setVisible(true);
        jf.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

	
    public static void main(String[] args) {
        javax.swing.SwingUtilities.invokeLater(new Runnable() {
            public void run() { createAndShowGUI(); }
        });        
    }

    
}