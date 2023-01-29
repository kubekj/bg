import React from "react";
import TrainerLeftPane from "../trainer-view/trainer-left-pane";

function Trainer({ children }) {
  return (
    <>
      <TrainerLeftPane />
      {children}
    </>
  );
}

export default Trainer;
