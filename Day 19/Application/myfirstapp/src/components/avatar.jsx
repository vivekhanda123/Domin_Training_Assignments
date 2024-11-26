import React from "react";
import img1 from "../assets/img1.jpg";
import img2 from "../assets/img2.jpeg";
import img3 from "../assets/img3.jpeg";

function Avatar({ person, size }) {
  return (
    <>
      <p>{person.name}</p>
      <p>{person.imageId}</p>
      <img src={person.imageId} alt={person.name} height={size} width={size} />
    </>
  );
}

export default function Profile() {
  return (
    <>
      <Avatar person={{ name: "person 1", imageId: img1 }} size={150} />
      <Avatar person={{ name: "person 2", imageId: img2 }} size={150} />
      <Avatar person={{ name: "person 3", imageId: img3 }} size={150} />
    </>
  );
}