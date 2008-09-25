﻿//-----------------------------------------------------------------------
// <copyright file="ITokenManager.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOAuth.ChannelElements {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	/// <summary>
	/// An interface OAuth hosts must implement for persistent storage and recall of tokens and secrets.
	/// </summary>
	public interface ITokenManager {
		/// <summary>
		/// Gets the Consumer Secret given a Consumer Key.
		/// </summary>
		/// <param name="consumerKey">The Consumer Key.</param>
		/// <returns>The Consumer Secret.</returns>
		string GetConsumerSecret(string consumerKey);

		/// <summary>
		/// Gets the Token Secret given a request or access token.
		/// </summary>
		/// <param name="token">The request or access token.</param>
		/// <returns>The secret associated with the given token.</returns>
		string GetTokenSecret(string token);

		/// <summary>
		/// Stores a newly generated unauthorized request token, secret, and optional
		/// application-specific parameters for later recall.
		/// </summary>
		/// <param name="consumerKey">The key of the Consumer that requested this token.</param>
		/// <param name="requestToken">The token to store.</param>
		/// <param name="requestTokenSecret">The secret to store as associated with the request token.</param>
		/// <param name="parameters">The optional application-specific parameters of this request.</param>
		void StoreNewRequestToken(string consumerKey, string requestToken, string requestTokenSecret, IDictionary<string, string> parameters);

		/// <summary>
		/// Deletes a request token and its associated secret and stores a new access token and secret.
		/// </summary>
		/// <param name="consumerKey">The Consumer that is exchanging its request token for an access token.</param>
		/// <param name="requestToken">The Consumer's request token that should be deleted/expired.</param>
		/// <param name="accessToken">The new access token that is being issued to the Consumer.</param>
		/// <param name="accessTokenSecret">The secret associated with the newly issued access token.</param>
		/// <remarks>
		/// Any scope of granted privileges associated with the request token from the
		/// original call to <see cref="StoreNewRequestToken"/> should be carried over
		/// to the new Access Token.
		/// </remarks>
		void ExpireRequestTokenAndStoreNewAccessToken(string consumerKey, string requestToken, string accessToken, string accessTokenSecret);
	}
}
