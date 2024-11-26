import React from "react";

export default function CoreConcept({ title, image, description }) {
  return (
    <li>
      <img src={image} alt={title} height={200} width={200}></img>
      <h3>{title}</h3>
      <p>{description}</p>
    </li>
  );
}