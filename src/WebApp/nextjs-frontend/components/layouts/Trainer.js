import React from "react";
import TrainerSidebar from "../trainer/sidebar";

function Trainer({ children }) {
  return (
    <>
      <TrainerSidebar />
      {children}
    </>
  );
}

export default Trainer;
