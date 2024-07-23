        /* this class will provide the functionality of 
           having persistent storage.
           
           Managing an xml document. Featuring: Songs, Playlists, ffmpegpath, yt-dlppath, and downloaddir
           
           Set stuff. Which writes it as well. Program init would interface with this.

           Main thing im thinking about is how state should work. Ideally I would have state be synced automatically.
           How? When setting stuff in the program, that would also set in a file. Thing is, is that the actual writer/reader for
           the file is a thing by itself. I'd be defining the same thing in multiple files. Is there a way not to? Map an object to
           an xml object. The idea, is that you can sync the persistent storage at any time.
           Make an object that would handle persistent storage. Like maybe when recieving a PreferencesChanged event, it would sync
           it to disk as well. What about loading? When intializing? 

           ConfigManager. In program.init, register an event handler for when prefrenceschanges which would sync data to disk. 
           Objects for everything? No imo. 
           
           PersistentData class. Just. Make. the. persistentdata. class. And after that, we'll see!
           It will have, SetSongs, SetPlaylists, SetOtherstuff, and a Sync method. The sync method is the interface the rest of the
           program uses. The rest are private.
        */

            /* make getters.
           Maybe make some stuff nicer implementation wise. Like wrappers for accessing xml nodes
           Proper playlists, maybe have internal id's?
        */

                    /* identify existing playlist, overwrite if it finds one.
               otherwise, just create one

               Try removing the existing playlist node. 

               Remove node if it exists
               Create new node
               Add playlists
               Write
            */

                        /* get appropriate node.
               maybe nodes as classes that wrap the thing.
               Maybe, just have functions, prefixed with what thing they represent. Maybe, get set
            */

                /* How? Xml file with stuff.    
       Located in AppData maybe... Maybe thingie... Whatever, it shouldnt matter as the path is just
       an arguement. 
       Anyways, what if the config is separate from the program..
       Like what is config in a program? What makes a config? The config reader could maybe just serialize the juice.
       And then have the program itself read that. Which makes it nice and modular.
       So, how it would look is that the config would ready itself, to be nice and easy. Then, the parts of the program
       that need it would do their thing when initializing.
       I keep thinking about how songs/playlists work. Songs just represent a song. Playlists represent a group of songs.
       How would you identify duplicates? With title? With youtube id? With filepath? 
       Now, with being able to identify duplicates. Thats a function it provides. Theres info that needs to exist for that
       to happen. Now, having an interface to fulfill these functions is nice. Thats how I should be thinking. Instead of
       thinking about how to structure the data. Yessir.

       Actually, how do I write it? How does a configwriter work?
       Maybe I just, when writing, put all of the stuff I want in there.
       And then call write.
       Should it be a part of the app? Or a tool? Thing is, is that the
       Config expects a format. And the format is part of the program.
       So like...
       Like, whats the point of making a config reader/writer, and then have to manually 
       put everything in there anyways. 
       Surely, there should be a way to write everything. Alternatively, write the
       config throughout the program. 
       How would you make a config thingie that isnt coupled to the program.
       And what purpose does that provide?
       Maybe, a explicit config object. I dont think that would be good...
       Maybe.... A config adapter. Or! A config reader. / adapter.
       So basically, the config reader would write directly into the app.
       Maybe I could set up the config reader to read from certain locations
       But, whats the point honestly.
       Map between xml and c#. Thats its purpose.
       Maybe a object between that that will load things in.
       I need to make a decision here. A config reader / writer that is
       directly integrated into the progrm. Or... Make it two parts.
       Personally, I dont see why it should be two parts. Thing is. Is that
       now I couple the program together. Then again, thats how it is I guess.
       For convenience I have to.
       Songs, playlists, ffmpegpath, yt-dlppath, downloaddir.
       Thing is, is that ffmpeg,yt-dlp and downloadir is all part of the
       YoutubeDownloader. Then again, they are also all part of the program.
       Because any place could techinally make use of them as well.
       How do I make an educated guess on the best route? 
       I think for being messy and whatever, the strat is to just make objects
       all over the place. So basically, this object will use program state.
       Its not very decoupled. But I dont really think it can be.
       So, config is an object. Program.config.SetPlaylists(playlists);
       Program.config.SetDownloadDir();
       Program.PersistentData;
       Storage, ProgramData, Data, Config, Saved, Preferences, Database,
       Saver
       songs/playlists and other stuff, put all in one.
       Actually, maybe not.
       Philosophical route: No convenience.
       Practical: All convenience.
       ConfigReader. Which does ALL of the work.
       Philosophical. Which everything does its own thing, and its annoying.
       Group by functionality. Which is more vague.
       Or dont group at all, which is more opinionless. And makes more sense
       in an abstract view. 
       Persistent data. Program has to store persistent data.

       Persistent.SetPlaylists();
       Persistent.SetSongs();
       Persistent.SetYtDlpPath;
       Persistent.SetFfmpegPath;
       Persistent.SetDownloadPath;

       PersistentAdapter.Update();

       Separating functionality
       XmlWriter. 
       I want to write xml objects. But to write these, I have to have a 
       special xml writer.
       Then I want a thing that writes the stuff in my program to this writer.
       Which would use that. 
       Now, how much should I split code up, at what point is it reasonable?
       idk. thats the thing.
       SpecializedXmlWriter, Adapter or configmanager.
       Messages, which the configmanager would pick up on.
       Whenever for example a song gets added. Then the configmanager
       will be sure to update the configfile with that.
       I need to justify everything. 
       Messages. ValueChange. SongAdded. PlaylistAdded. FfmpegPathChanged.
       YtdlpPathChanged. DownloadDirChanged.
       ConfigManager, YoutubeDownloader.
       SongAdded: songview.
       I guess the confusing thing is, is that you would have so many objects.
       So much stuff happening. Things all over communicating. Alot of 
       abstraction. Possibly, inperfect abstraction. Spooky!

       public Update();

       xmldocument writer is separate.
    */

    /* Should app config be in here?
   on one hand, it makes sense. But if you think that the program should be made up of multiple
   objects, then maybe it would make more sense to put the config in the appropriate locations.
   Because the YoutubeDownloader requires both ytdlp and ffmpeg, maybe it makes more sense to have
   those parameters in the YoutubeDownloader object... Im wondering about structure. In the end
   this program fulfills a purpose. The program itself, so should the program or the mainform
   be where things exist? The mainform is the interface, the program is the juice. Or more so,
   the rest of the program is the juice. Any forms are just the interface. Personally, just
   intuitevly, I think it makes sense to have basic stuff like dependency paths here. Or somewhere
   else really. Just right now, I think it makes sense to put it here. Theres no real reason to organize
   too much when its literally a line of code. Also, its kind of like a constant. So whatever. Right?
*/