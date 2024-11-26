import React,{useState} from "react";

const servers = [
    {id:1,name:"Google Drive",location:"New York",isOnline:true},
    {id:2,name:"Azure Drive",location:"USA",isOnline:false},
    {id:3,name:"Microsoft Drive",location:"India",isOnline:true},
    {id:4,name:"Apple Drive",location:"Germany",isOnline:false},
];
export default function ServerStatus(){
    return(
        <>
            <div className="server-list">
                {servers.map((server)=>(
                    <div 
                    key = {server.id}
                    className="server-item"
                    style={{color:server.isOnline ? "green":"red"}}>
                        <h3>{server.name}</h3>
                        <p>Location : {server.location}</p>
                        <p>Status: {server.isOnline ? "Online" : "Offline"}</p>
                    </div>
                ))}
            </div>
        </>
    );
}