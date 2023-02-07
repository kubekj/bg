import style from "./header.module.css";
import Image from "next/image";
import Link from "next/link";

const ButtonsSection = ({
  leftBottomSectionText,
  rightBottomSectionText,
  isLogin,
}) => {
  return (
    <div
      className='btn-group-vertical w-100'
      role='group'
      aria-label='Vertical button group'
    >
      <p className='text-center mt-3 w-100'>
        {leftBottomSectionText}{" "}
        <Link
          className=' text-decoration-none'
          href={isLogin ? "/auth/signup" : "/auth/login"}
          style={{ color: "#98B3DB" }}
        >
          {rightBottomSectionText}
        </Link>
      </p>
    </div>
  );
};

export default ButtonsSection;
