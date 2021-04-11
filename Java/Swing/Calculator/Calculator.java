package Calculator;

import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class Calculator {

    public static void createAndShowGUI() {

        JFrame jf = new JFrame("Calculator");

        JTextField jtf = new JTextField();
        jf.getContentPane().add(jtf, BorderLayout.NORTH);

        JPanel jp = new JPanel();
        jf.getContentPane().add(jp, BorderLayout.CENTER);
        jp.setLayout(new GridLayout(4, 4));

        String buttons[] = {"1", "2", "3", "+",
                            "4", "5", "6", "-", 
                            "7", "8", "9", "*", 
                            "C", "0", "=", "/"};

        myActionListener myActionListener = new myActionListener(jtf);

        for (String button : buttons) {
            JButton jb = new JButton(button);
            jp.add(jb);
            jb.addActionListener(myActionListener);
        }

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

class myActionListener implements ActionListener {
    char operator;
    int in1, in2;
    Boolean operatorPresent = false;
    Boolean previousWasNumber = true;
    JTextField jtf;
    public myActionListener(JTextField _jtf){
        jtf = _jtf;        
    }
    public void actionPerformed(ActionEvent e) {
        char input = e.getActionCommand().charAt(0);
        if (input != 'C')
            System.out.println(input);
        jtf.setText(jtf.getText() + input);
        switch(input){
        case '+':
            if(!operatorPresent){
                operatorPresent = true;
                previousWasNumber = false;
            }
            else{
                if(!previousWasNumber){
                    operator = input;
                    jtf.setText(jtf.getText().substring(0, jtf.getText().length() - 2));
                    jtf.setText(jtf.getText() + input);
                }
                else{
                    in2 = 0;
                }
            }
            operator = input;
            break;
        case '-':
            if(!operatorPresent){
                operatorPresent = true;
                previousWasNumber = false;
            }
            else{
                if(!previousWasNumber){
                    operator = input;
                    jtf.setText(jtf.getText().substring(0, jtf.getText().length() - 2));
                    jtf.setText(jtf.getText() + input);
                }
                else{
                    in2 = 0;
                }
            }
            operator = input;
            break;
        case '*':
            if(!operatorPresent){
                operatorPresent = true;
                previousWasNumber = false;
            }
            else{
                if(!previousWasNumber){
                    operator = input;
                    jtf.setText(jtf.getText().substring(0, jtf.getText().length() - 2));
                    jtf.setText(jtf.getText() + input);
                }
                else{
                    in2 = 0;
                }
            }
            operator = input;
            break;
        case '/':
            if(!operatorPresent){
                operatorPresent = true;
                previousWasNumber = false;
            }
            else{
                if(!previousWasNumber){
                    operator = input;
                    jtf.setText(jtf.getText().substring(0, jtf.getText().length() - 2));
                    jtf.setText(jtf.getText() + input);
                }
                else{
                    in2 = 0;
                }
            }
            operator = input;
            break;
        case 'C':
            in1 = 0;
            in2 = 0;
            operatorPresent = false;
            previousWasNumber = true;
            operator = 0;
            jtf.setText("");
            break;
        case '=':
            String output = "";
            int temp = 0;
            switch(operator){
                case '+':
                    temp = in1 + in2;
                    output = ("" + temp);
                    break;
                case '-':
                    temp = in1 - in2;
                    output = ("" + temp);  
                    break;
                case '*':
                    temp = in1 * in2;
                    output = ("" + temp);
                    break;
                case '/':
                    try{
                        temp = in1 / in2;
                        output = ("" + temp);
                    } catch (ArithmeticException exc){
                        System.err.println("Division by zero detected! Calculator Reset.");
                        in1 = 0;
                        in2 = 0;
                        operatorPresent = false;
                        previousWasNumber = true;
                        operator = 0;
                        output = "";
                        jtf.setText("");
                    }                        
                    break;                
            }
            in1 = temp;
            System.out.println(output);
            jtf.setText(jtf.getText() + output);                    
            break;                    
        default:
            previousWasNumber = true;
            if(!operatorPresent){
                in1 = Integer.valueOf("" + in1 + (input - 48));
            } else
                in2 = Integer.valueOf("" + in2 + (input - 48));                        
        }
    }    		
}