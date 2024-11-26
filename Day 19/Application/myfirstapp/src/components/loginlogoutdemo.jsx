import React, {useState} from "react";

export default function LoginLogout(){
    const[isLoggdedIn,setIsLoggedIn] = useState(false);
    const[user,setUser] = useState(null);
    // const handleLogin = () =>{
    //     setIsLoggedIn(true);
    //     setUser({name:"Hexaware"});
    // };
    // const handleLogout = () =>{
    //     setIsLoggedIn(false);
    //     setUser(null);
    // };

    return(
        // <div>
        //     {
        //         isLoggdedIn?(
        //             <div>
        //             <h1>Welcome user, {user.name}</h1>
        //             <button onClick={handleLogout}>Logout</button>
        //         </div>
        //         ):(
        //             <div>
        //                 <h1>Please login</h1>
        //                 <button onClick={handleLogin}>Login</button>
        //             </div>
        //         )
        //     } 
        // </div>
        <div>
            {isLoggdedIn?(
                     <div>
                     <h1>Welcome user, {user.name}</h1>
                     <button onClick={()=>{
                        setIsLoggedIn(false);
                        setUser(null);
                     }}>Logout</button>
                 </div>
                 ):(
                     <div>
                         <h1>Please login</h1>
                         <button onClick={()=>{
                            setIsLoggedIn(true);
                            setUser({name:"to Hexaware"});
                         }}>Login</button>
                     </div>
              )
            }
        </div>
    )
}