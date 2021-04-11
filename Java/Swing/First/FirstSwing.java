package First;

// import java.awt.FlowLayout;
import java.awt.BorderLayout;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;

public class FirstSwing {
    private static BufferedImage image;

    public static void createAndShowGUI() {

        ActionListener myActionListener = new ActionListener() {
    		public void actionPerformed(ActionEvent e) {
    			System.out.println("Button = "+e.getActionCommand());
    		}    		
    	};

        JFrame jf = new JFrame("My First Frame");
        jf.setLayout(new BorderLayout());

        JButton jb = new JButton("Hello!");
        jb.addActionListener(myActionListener); // object is created
        jf.getContentPane().add(jb, BorderLayout.SOUTH);

        JButton jb2 = new JButton("How are you?");
        jb2.addActionListener(myActionListener); // object is created
        jf.getContentPane().add(jb2, BorderLayout.CENTER);

        try{
            image = ImageIO.read(new File("PeterGriffin.png"));
        }
        catch(IOException e){
            System.out.println("Oopsie 😁");
        }

        JLabel picLabel = new JLabel(new ImageIcon(image));
        jf.getContentPane().add(picLabel, BorderLayout.NORTH);

        jf.pack();
        jf.setVisible(true);
        jf.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

	
    public static void main(String[] args) {
        System.out.println("Before");
        
        javax.swing.SwingUtilities.invokeLater(new Runnable() {
            public void run() { createAndShowGUI(); }
        });
        
        System.out.println("After");
    }

}