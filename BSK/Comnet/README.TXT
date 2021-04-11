CACI COMNET III  Release 1.3 (Beta)
Monday, November 25, 1996

Last minute changes to documentation and software are noted here.

Configuration file name changes

   A new configuration file, Comnet3.cfg, replaces the old Comnet.ini.  It is
   not user editable.

   A new configuration file, Comnet3.ini, replaces the old meta.ini.  It IS
   user editable.  Changes you make to your environment, such as window size
   and position, are automatically stored in this file.  A copy is created in
   your Comnet working directory, so different users with different working
   directories can have different environment settings.  The behavior was the
   same in release 1.2, only the name has changed.

   The preferred way to change the default text file editor used by Comnet is to change
   the TextFileEditor setting in Comnet3.ini.

   Here is a list of some of the other parameters that can be set in the Comnet3.ini file:

     [Report Options]
     TextFileEditor=notepad        Change "notepad" if you want to use a different editor

     [Snapshot Options]            With release 1.3, the default color used to indicate
     DefaultMeasureColor=Yellow    snapshot measures was changed to yellow.  This can
                                   changed on a per-model basis using the Snapshot Measure
                                   Color option of the Layout menu.  In addition, the 
                                   default for all models can be changed with this ini 
                                   file parameter

Directories
   
   There's a new directory, Models, under the Comnet directory.  Sample models
   are put there, and if you don't change Comnet's default working directory,
   then your models will all go there as well.

Documentation

   A new Help menu option, Reference Manual, allows you to read the online reference
   manual that comes with the CD-ROM distribution of release 1.3.

Snapshots

   During the simulation, the camera button allows you to look at a summary
   of all snapshots turned on for an object.  Now, if you have more than one
   object selected, the camera button has the effect of updating the snapshot
   measures of those objects only, without also bringing up the summary 
   dialogs for all the objects.
