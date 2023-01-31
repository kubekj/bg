import MarketplaceMainView from "../../../components/athlete-view/athlete-marketplace/marketplace-main-view";
import Athlete from "../../../components/layouts/Athlete";
import {getSession} from "next-auth/react";


// export async function getServerSideProps(context) {
//   const session = await getSession({req: context.req});

// if (!session) {
//   return {
//     redirect: {
//       destination: "/auth/login",
//       permanent: false,
//     },
//   };
// }
//
//   return {
//     props: { jwt: session.jwt },
//   };
// }

const AthleteMarketplace = ({jwt}) => {
    return <MarketplaceMainView />
}

export default AthleteMarketplace;

AthleteMarketplace.layout = Athlete;