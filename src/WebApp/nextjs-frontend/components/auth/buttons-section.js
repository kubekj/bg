import style from "./header.module.css";
import Image from "next/image";

const ButtonsSection = ({
  topButtonText,
  bottomButtonText,
  leftBottomSectionText,
  rightBottomSectionText,
}) => {
  return (
    <div
      className='btn-group-vertical w-100'
      role='group'
      aria-label='Vertical button group'
    >
      <button
        type='button'
        className='btn mt-2 rounded'
        style={{ backgroundColor: "#98B3DB", color: "white" }}
      >
        {topButtonText}
      </button>
      <button
        type='button'
        className='btn mt-3 rounded'
        style={{ borderColor: "#98B3DB" }}
      >
        <img
          src='https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/512px-Google_%22G%22_Logo.svg.png'
          style={{ width: "1.2rem", height: "1.2rem", marginRight: "0.75rem" }}
          width={30}
          height={30}
        />
        {bottomButtonText}
      </button>
      <p className='text-center mt-3 w-100'>
        {leftBottomSectionText}{" "}
        <a
          className=' text-decoration-none'
          href='#'
          style={{ color: "#98B3DB" }}
        >
          {rightBottomSectionText}
        </a>
      </p>
    </div>
  );
};

export default ButtonsSection;
